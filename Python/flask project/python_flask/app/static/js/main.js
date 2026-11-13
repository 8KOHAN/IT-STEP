(() => {
    'use strict';

    const root = document.documentElement;
    const body = document.body;
    root.dataset.js = 'ready';

    const formatMoney = (value) => new Intl.NumberFormat('uk-UA').format(Number(value) || 0);

    /* Theme preference is persistent and does not trigger a navigation. */
    const themeToggle = document.querySelector('[data-theme-toggle]');
    const applyTheme = (theme) => {
        const nextTheme = theme === 'paper' ? 'paper' : 'dark';
        root.dataset.theme = nextTheme;
        try {
            localStorage.setItem('krok-atlas-theme', nextTheme);
        } catch (_) {
            // The current page theme still works when storage is unavailable.
        }
        themeToggle?.setAttribute('aria-label', nextTheme === 'dark' ? 'Увімкнути світлу тему' : 'Увімкнути темну тему');
        document.querySelector('meta[name="theme-color"]')?.setAttribute('content', nextTheme === 'dark' ? '#090b0b' : '#e9e6dc');
    };
    applyTheme(root.dataset.theme);
    themeToggle?.addEventListener('click', () => applyTheme(root.dataset.theme === 'dark' ? 'paper' : 'dark'));

    /* Mobile navigation. */
    const menuToggle = document.querySelector('[data-menu-toggle]');
    const mobileNav = document.querySelector('[data-mobile-nav]');
    const closeMenu = () => {
        menuToggle?.setAttribute('aria-expanded', 'false');
        mobileNav?.classList.remove('is-open');
        body.classList.remove('menu-open');
    };
    menuToggle?.addEventListener('click', () => {
        const nextOpen = menuToggle.getAttribute('aria-expanded') !== 'true';
        menuToggle.setAttribute('aria-expanded', String(nextOpen));
        mobileNav?.classList.toggle('is-open', nextOpen);
        body.classList.toggle('menu-open', nextOpen);
    });
    mobileNav?.querySelectorAll('a').forEach((link) => link.addEventListener('click', closeMenu));
    window.addEventListener('resize', () => {
        if (window.innerWidth > 820) closeMenu();
    });

    /* Header time and scroll progress are small ambient interface signals. */
    const timeNode = document.querySelector('[data-kyiv-time]');
    const updateKyivTime = () => {
        if (!timeNode) return;
        timeNode.textContent = new Intl.DateTimeFormat('uk-UA', {
            timeZone: 'Europe/Kyiv', hour: '2-digit', minute: '2-digit', hour12: false,
        }).format(new Date());
    };
    updateKyivTime();
    window.setInterval(updateKyivTime, 30000);

    const scrollMeter = document.querySelector('[data-scroll-meter]');
    const updateScrollMeter = () => {
        if (!scrollMeter) return;
        const available = document.documentElement.scrollHeight - window.innerHeight;
        const progress = available > 0 ? (window.scrollY / available) * 100 : 0;
        scrollMeter.style.width = `${Math.min(100, Math.max(0, progress))}%`;
    };
    window.addEventListener('scroll', updateScrollMeter, { passive: true });
    window.addEventListener('resize', updateScrollMeter);
    updateScrollMeter();

    document.querySelectorAll('[data-scroll-top]').forEach((link) => {
        link.addEventListener('click', (event) => {
            event.preventDefault();
            window.scrollTo({ top: 0, behavior: 'smooth' });
        });
    });

    /* Route Engine data: selection changes the visual route and catalog filter. */
    const routeModes = {
        'бетон': {
            code: 'R/01 — CONCRETE LINES',
            title: 'РІВНІ ЛІНІЇ.<br>ЧІТКИЙ КРОК.',
            description: 'Міський рельєф, тверде покриття, короткі переходи та довгі дні.',
        },
        'асфальт': {
            code: 'R/02 — ASPHALT FLOW',
            title: 'ТРИМАЙ<br>СВІЙ ТЕМП.',
            description: 'Швидкий міський ритм, довгі дистанції та постійний рух уперед.',
        },
        'ґрунт': {
            code: 'R/03 — OPEN GROUND',
            title: 'ЗА МЕЖАМИ<br>ЗВИЧНОГО.',
            description: 'Менше прямих ліній, більше свободи. Маршрут не зобов’язаний бути гладким.',
        },
        'ніч': {
            code: 'R/04 — AFTER DARK',
            title: 'МІСТО<br>ПІСЛЯ ТЕМРЯВИ.',
            description: 'Після заходу сонця вулиці змінюють ритм. Твій рух — ні.',
        },
    };

    const routeOptions = [...document.querySelectorAll('[data-route-surface]')];
    const routeCode = document.querySelector('[data-route-code]');
    const routeTitle = document.querySelector('[data-route-title]');
    const routeDescription = document.querySelector('[data-route-description]');
    const routeResults = document.querySelector('[data-route-results]');
    const routeConsole = document.querySelector('[data-route-console]');
    let selectedRoute = routeOptions.find((option) => option.classList.contains('is-active'))?.dataset.routeSurface || 'бетон';

    const getCards = () => [...document.querySelectorAll('[data-product-card]')];
    const countForSurface = (surface) => getCards().filter((card) => (card.dataset.surfaces || '').split(',').includes(surface)).length;

    const updateRouteReadout = () => {
        const mode = routeModes[selectedRoute];
        if (!mode) return;
        routeConsole?.setAttribute('data-route-mode', selectedRoute);
        if (routeCode) routeCode.textContent = mode.code;
        if (routeTitle) routeTitle.innerHTML = mode.title;
        if (routeDescription) routeDescription.textContent = mode.description;
        if (routeResults) routeResults.textContent = `${String(countForSurface(selectedRoute)).padStart(2, '0')} / 08 ОБ’ЄКТІВ`;
    };

    routeOptions.forEach((option) => {
        option.addEventListener('click', () => {
            selectedRoute = option.dataset.routeSurface || 'бетон';
            routeOptions.forEach((item) => {
                const active = item === option;
                item.classList.toggle('is-active', active);
                item.setAttribute('aria-pressed', String(active));
            });
            updateRouteReadout();
        });
    });

    /* Catalog filtering runs entirely in the current document. */
    const productGrid = document.querySelector('[data-product-grid]');
    const categoryButtons = [...document.querySelectorAll('[data-category]')];
    const searchInput = document.querySelector('[data-catalog-search]');
    const sortSelect = document.querySelector('[data-catalog-sort]');
    const visibleCount = document.querySelector('[data-visible-count]');
    const catalogState = document.querySelector('[data-catalog-state]');
    const emptyState = document.querySelector('[data-catalog-empty]');
    const clearFiltersButtons = [...document.querySelectorAll('[data-clear-filters]')];
    const initialParams = new URLSearchParams(window.location.search);
    let activeCategory = initialParams.get('category') || 'Усе';
    let activeSurface = initialParams.get('surface') || '';

    if (searchInput && initialParams.has('q')) searchInput.value = initialParams.get('q') || '';
    if (sortSelect && initialParams.has('sort')) sortSelect.value = initialParams.get('sort') || 'featured';
    if (!routeModes[activeSurface]) activeSurface = '';
    if (activeSurface) {
        selectedRoute = activeSurface;
        routeOptions.forEach((option) => {
            const active = option.dataset.routeSurface === selectedRoute;
            option.classList.toggle('is-active', active);
            option.setAttribute('aria-pressed', String(active));
        });
    }
    updateRouteReadout();

    const updateUrl = () => {
        const params = new URLSearchParams();
        if (activeCategory !== 'Усе') params.set('category', activeCategory);
        const query = (searchInput?.value || '').trim();
        if (query) params.set('q', query);
        const sort = sortSelect?.value || 'featured';
        if (sort !== 'featured') params.set('sort', sort);
        if (activeSurface) params.set('surface', activeSurface);
        const nextUrl = `${window.location.pathname}${params.size ? `?${params.toString()}` : ''}${window.location.hash}`;
        window.history.replaceState({}, '', nextUrl);
    };

    const setCategory = (category) => {
        activeCategory = category;
        categoryButtons.forEach((button) => {
            const active = button.dataset.category === category;
            button.classList.toggle('is-active', active);
            button.setAttribute('aria-pressed', String(active));
        });
    };

    const applyFilters = () => {
        if (!productGrid) return;
        const query = (searchInput?.value || '').trim().toLocaleLowerCase('uk');
        const sort = sortSelect?.value || 'featured';
        const visibleCards = [];

        getCards().forEach((card) => {
            const surfaces = (card.dataset.surfaces || '').split(',');
            const searchable = [card.dataset.name, card.dataset.category, card.dataset.color, card.dataset.description, card.dataset.surfaces].join(' ').toLocaleLowerCase('uk');
            const categoryMatch = activeCategory === 'Усе' || card.dataset.category === activeCategory;
            const queryMatch = !query || searchable.includes(query);
            const surfaceMatch = !activeSurface || surfaces.includes(activeSurface);
            const matches = categoryMatch && queryMatch && surfaceMatch;
            card.hidden = !matches;
            if (matches) visibleCards.push(card);
        });

        const sorters = {
            'price-asc': (a, b) => Number(a.dataset.price) - Number(b.dataset.price),
            'price-desc': (a, b) => Number(b.dataset.price) - Number(a.dataset.price),
            newest: (a, b) => Number(b.dataset.new === 'true') - Number(a.dataset.new === 'true') || Number(a.dataset.order) - Number(b.dataset.order),
            featured: (a, b) => Number(a.dataset.order) - Number(b.dataset.order),
        };
        visibleCards.sort(sorters[sort] || sorters.featured).forEach((card) => productGrid.appendChild(card));

        const count = visibleCards.length;
        if (visibleCount) visibleCount.textContent = String(count).padStart(2, '0');
        if (catalogState) {
            const categoryLabel = activeCategory === 'Усе' ? 'ALL OBJECTS' : activeCategory.toLocaleUpperCase('uk');
            const surfaceLabel = activeSurface ? ` / ${activeSurface.toLocaleUpperCase('uk')}` : '';
            catalogState.textContent = `ПОКАЗАНО ${String(count).padStart(2, '0')} ОБ’ЄКТІВ / ${categoryLabel}${surfaceLabel}`;
        }
        if (emptyState) emptyState.hidden = count !== 0;
        productGrid.hidden = count === 0;
        updateUrl();
    };

    categoryButtons.forEach((button) => {
        button.addEventListener('click', () => {
            setCategory(button.dataset.category || 'Усе');
            activeSurface = '';
            applyFilters();
        });
    });
    searchInput?.addEventListener('input', applyFilters);
    sortSelect?.addEventListener('change', applyFilters);
    clearFiltersButtons.forEach((button) => button.addEventListener('click', () => {
        setCategory('Усе');
        activeSurface = '';
        selectedRoute = 'бетон';
        routeOptions.forEach((option) => {
            const active = option.dataset.routeSurface === selectedRoute;
            option.classList.toggle('is-active', active);
            option.setAttribute('aria-pressed', String(active));
        });
        if (searchInput) searchInput.value = '';
        if (sortSelect) sortSelect.value = 'featured';
        updateRouteReadout();
        applyFilters();
    }));

    document.querySelector('[data-apply-route]')?.addEventListener('click', () => {
        activeSurface = selectedRoute;
        setCategory('Усе');
        applyFilters();
        document.querySelector('#catalog')?.scrollIntoView({ behavior: 'smooth', block: 'start' });
    });

    if (productGrid) {
        setCategory(categoryButtons.some((button) => button.dataset.category === activeCategory) ? activeCategory : 'Усе');
        if (sortSelect && initialParams.has('sort')) sortSelect.value = initialParams.get('sort') || 'featured';
        applyFilters();
        window.addEventListener('popstate', () => {
            const params = new URLSearchParams(window.location.search);
            setCategory(params.get('category') || 'Усе');
            activeSurface = routeModes[params.get('surface')] ? params.get('surface') : '';
            if (searchInput) searchInput.value = params.get('q') || '';
            if (sortSelect) sortSelect.value = params.get('sort') || 'featured';
            if (activeSurface) selectedRoute = activeSurface;
            routeOptions.forEach((option) => {
                const active = option.dataset.routeSurface === selectedRoute;
                option.classList.toggle('is-active', active);
                option.setAttribute('aria-pressed', String(active));
            });
            updateRouteReadout();
            applyFilters();
        });
    }

    /* Shoe size selector. */
    document.querySelectorAll('[data-size-option]').forEach((button) => {
        button.addEventListener('click', () => {
            const grid = button.closest('.size-grid');
            grid?.querySelectorAll('[data-size-option]').forEach((option) => {
                const active = option === button;
                option.classList.toggle('is-selected', active);
                option.setAttribute('aria-pressed', String(active));
            });
            const size = button.dataset.size || button.textContent.trim();
            const hiddenInput = document.querySelector('[data-selected-size]');
            const feedback = document.querySelector('[data-size-feedback]');
            if (hiddenInput) hiddenInput.value = size;
            if (feedback) feedback.textContent = `ОБРАНО РОЗМІР ${size} EU`;
        });
    });

    /* Toasts and asynchronous cart/favorite actions keep the page in place. */
    const toastStack = document.querySelector('[data-toast-stack]');
    const showToast = (message, kind = 'success') => {
        if (!toastStack) return;
        const toast = document.createElement('div');
        toast.className = `toast toast--${kind}`;
        toast.setAttribute('role', 'status');
        const signal = document.createElement('span');
        signal.className = 'toast__signal';
        const text = document.createElement('span');
        text.textContent = message;
        const close = document.createElement('button');
        close.type = 'button';
        close.dataset.toastClose = '';
        close.setAttribute('aria-label', 'Закрити повідомлення');
        close.textContent = '×';
        toast.append(signal, text, close);
        toastStack.appendChild(toast);
        window.setTimeout(() => toast.remove(), 4500);
    };

    const updateBagCount = (count) => {
        document.querySelectorAll('[data-bag-count]').forEach((node) => { node.textContent = String(count); });
    };
    const updateBagSummary = (data) => {
        document.querySelectorAll('[data-bag-items-count], [data-bag-summary-count]').forEach((node) => { node.textContent = String(data.items_count); });
        const total = document.querySelector('[data-bag-total]');
        if (total) total.innerHTML = `${formatMoney(data.total)} <small>₴</small>`;
    };

    document.addEventListener('click', (event) => {
        const closeButton = event.target.closest('[data-toast-close]');
        if (closeButton) closeButton.closest('.toast')?.remove();
    });

    document.querySelectorAll('form[data-async-form]').forEach((form) => {
        form.addEventListener('submit', async (event) => {
            event.preventDefault();
            const submitButton = form.querySelector('button[type="submit"]');
            if (submitButton?.disabled) return;
            const mode = form.dataset.asyncForm;
            const originalLabel = submitButton?.innerHTML;
            if (submitButton) {
                submitButton.disabled = true;
                submitButton.setAttribute('aria-busy', 'true');
            }
            form.classList.add('is-loading');

            try {
                const response = await fetch(form.action, {
                    method: 'POST',
                    body: new FormData(form),
                    headers: { Accept: 'application/json', 'X-Requested-With': 'XMLHttpRequest' },
                    credentials: 'same-origin',
                });
                const data = await response.json();
                if (!response.ok || !data.ok) throw new Error(data.message || 'Не вдалося виконати дію.');

                if (Number.isFinite(data.bag_count)) updateBagCount(data.bag_count);
                if (mode === 'favorite') {
                    const button = form.querySelector('.favorite-button, .detail-favorite');
                    button?.classList.toggle('is-favorite', Boolean(data.is_favorite));
                    button?.setAttribute('aria-pressed', String(Boolean(data.is_favorite)));
                    if (button?.classList.contains('favorite-button')) {
                        button.setAttribute('aria-label', data.is_favorite ? 'Прибрати зі збережених' : 'Зберегти пару');
                    }
                    const label = button?.querySelector('span');
                    if (label) label.textContent = data.is_favorite ? '♥ У ЗБЕРЕЖЕНИХ' : '♡ ЗБЕРЕГТИ ОБ’ЄКТ';
                    showToast(data.message || 'Стан збереження оновлено.');
                } else if (mode === 'remove') {
                    form.closest('[data-bag-item]')?.remove();
                    updateBagSummary(data);
                    if (data.items_count === 0) {
                        document.querySelector('[data-bag-layout]')?.setAttribute('hidden', '');
                        document.querySelector('[data-bag-empty]')?.removeAttribute('hidden');
                    }
                    showToast(data.message || 'Позицію прибрано.');
                } else {
                    showToast(data.message || 'Пару додано до маршруту.');
                    if (submitButton) {
                        submitButton.innerHTML = '<span>ДОДАНО</span><b>✓</b>';
                        window.setTimeout(() => {
                            if (submitButton.isConnected && originalLabel) submitButton.innerHTML = originalLabel;
                        }, 1300);
                    }
                }
            } catch (error) {
                showToast(error instanceof Error ? error.message : 'Помилка з’єднання. Спробуй ще раз.', 'error');
            } finally {
                form.classList.remove('is-loading');
                if (submitButton) {
                    submitButton.disabled = false;
                    submitButton.removeAttribute('aria-busy');
                }
            }
        });
    });

    /* Small pointer response on the editorial image. */
    const heroVisual = document.querySelector('[data-hero-visual]');
    if (heroVisual && window.matchMedia('(pointer: fine)').matches) {
        heroVisual.addEventListener('pointermove', (event) => {
            const rect = heroVisual.getBoundingClientRect();
            heroVisual.style.setProperty('--pointer-x', `${((event.clientX - rect.left) / rect.width) * 100}%`);
            heroVisual.style.setProperty('--pointer-y', `${((event.clientY - rect.top) / rect.height) * 100}%`);
        });
        heroVisual.addEventListener('pointerleave', () => {
            heroVisual.style.setProperty('--pointer-x', '50%');
            heroVisual.style.setProperty('--pointer-y', '50%');
        });
    }

    /* A graceful fallback in case an external photo is unavailable. */
    const fallbackImage = 'https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=1200&q=85';
    document.querySelectorAll('img').forEach((image) => {
        image.addEventListener('error', () => {
            if (image.dataset.fallbackApplied === 'true') return;
            image.dataset.fallbackApplied = 'true';
            image.src = fallbackImage;
        });
    });
})();
