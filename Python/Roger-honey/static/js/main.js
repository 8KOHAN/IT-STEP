(() => {
    "use strict";

    const root = document.documentElement;
    const body = document.body;
    const header = document.querySelector("[data-header]");
    const menuToggle = document.querySelector("[data-menu-toggle]");
    const navigation = document.querySelector("[data-main-nav]");
    const progressBar = document.querySelector("[data-scroll-progress]");
    const reduceMotion = window.matchMedia("(prefers-reduced-motion: reduce)");

    root.classList.add("js");

    const closeMenu = () => {
        if (!menuToggle || !navigation) {
            return;
        }

        menuToggle.setAttribute("aria-expanded", "false");
        menuToggle.setAttribute("aria-label", "Відкрити меню");
        navigation.classList.remove("is-open");
        body.classList.remove("menu-open");
    };

    const openMenu = () => {
        if (!menuToggle || !navigation) {
            return;
        }

        menuToggle.setAttribute("aria-expanded", "true");
        menuToggle.setAttribute("aria-label", "Закрити меню");
        navigation.classList.add("is-open");
        body.classList.add("menu-open");
    };

    if (menuToggle && navigation) {
        menuToggle.addEventListener("click", () => {
            const isExpanded = menuToggle.getAttribute("aria-expanded") === "true";
            if (isExpanded) {
                closeMenu();
            } else {
                openMenu();
            }
        });

        navigation.querySelectorAll("a").forEach((link) => {
            link.addEventListener("click", closeMenu);
        });

        document.addEventListener("keydown", (event) => {
            if (event.key === "Escape") {
                closeMenu();
            }
        });

        window.addEventListener("resize", () => {
            if (window.innerWidth > 900) {
                closeMenu();
            }
        });
    }

    const updateScrollState = () => {
        const scrollTop = window.scrollY || root.scrollTop || 0;
        const scrollableHeight = root.scrollHeight - window.innerHeight;
        const progress = scrollableHeight > 0 ? scrollTop / scrollableHeight : 0;

        if (header) {
            header.classList.toggle("is-scrolled", scrollTop > 24);
        }

        if (progressBar) {
            progressBar.style.transform = `scaleX(${Math.min(1, Math.max(0, progress))})`;
        }
    };

    let scrollTicking = false;
    window.addEventListener(
        "scroll",
        () => {
            if (scrollTicking) {
                return;
            }

            scrollTicking = true;
            window.requestAnimationFrame(() => {
                updateScrollState();
                scrollTicking = false;
            });
        },
        { passive: true }
    );

    window.addEventListener("resize", updateScrollState, { passive: true });
    updateScrollState();

    const revealElements = document.querySelectorAll(".reveal");

    if (reduceMotion.matches || !("IntersectionObserver" in window)) {
        revealElements.forEach((element) => element.classList.add("is-visible"));
    } else {
        const revealObserver = new IntersectionObserver(
            (entries, observer) => {
                entries.forEach((entry) => {
                    if (!entry.isIntersecting) {
                        return;
                    }

                    entry.target.classList.add("is-visible");
                    observer.unobserve(entry.target);
                });
            },
            {
                root: null,
                rootMargin: "0px 0px -7% 0px",
                threshold: 0.08,
            }
        );

        revealElements.forEach((element) => revealObserver.observe(element));
    }

    document.querySelectorAll('a[href^="#"]').forEach((link) => {
        link.addEventListener("click", (event) => {
            const targetId = link.getAttribute("href");
            if (!targetId || targetId === "#") {
                return;
            }

            const target = document.querySelector(targetId);
            if (!target) {
                return;
            }

            event.preventDefault();
            target.scrollIntoView({
                behavior: reduceMotion.matches ? "auto" : "smooth",
                block: "start",
            });

            if (window.history && window.history.replaceState) {
                window.history.replaceState(null, "", targetId);
            }
        });
    });
})();
