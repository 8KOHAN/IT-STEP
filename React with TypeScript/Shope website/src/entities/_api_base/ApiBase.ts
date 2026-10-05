/*
Централізація задач надсилання запитів, кешування результатів тощо
*/
interface ICacheItem {
    responseBody: object,
    expires: number,
};

const cache:Record<string, ICacheItem> = { };

export default class ApiBase {
    static getCached(url:string, conf?:object, fallback?:object):Promise<object> {
        return new Promise((resolve, reject) => {
            // url - адреса запиту (з усіма параметрами)
            // виступає як ключ для кешу

            // перед запитом перевіряємо чи є збережений кеш
            if(typeof cache[url] != 'undefined') {
                // перевіряємо термін придатності
                if(cache[url].expires > new Date().getTime()) {
                    console.log(url, "Cache used");
                    resolve(cache[url].responseBody);
                    return;
                }
            }

            if(url.startsWith('/')) {   // скорочена (відносна) адреса
                // додаємо адресу бекенду
                url = "https://localhost:7149/api" + url;
            }
            fetch(url, conf)
            .then(r => r.json())   // REST - це точно JSON
            .then(j => {
                // зберігаємо одержані дані до кешу
                cache[url] = {
                    responseBody: j,
                    expires: new Date().getTime() + 100000
                };
                resolve(j); 
            })
            .catch(reject);  // TODO: get fallback
        });
    }

    static getCachedOld(url:string, conf?:object, fallback?:object):Promise<object> {
        return new Promise((resolve, reject) => {
            // url - адреса запиту (з усіма параметрами)
            // виступає як ключ для кешу

            // перед запитом перевіряємо чи є збережений кеш
            if(typeof cache[url] != 'undefined') {
                // перевіряємо термін придатності
                if(cache[url].expires > new Date().getTime()) {
                    console.log(url, "Cache used");
                    resolve(cache[url].responseBody);
                    return;
                }
            }
            // в реальному проєкті запускаємо fetch
            // в режимі імітації бекенду передаємо fallback, який
            //  будуть формувати АРІ для задач тестування
            setTimeout(() => {
                try {
                    const data = fallback!;
                    // зберігаємо одержані дані до кешу
                    cache[url] = {
                        responseBody: data,
                        expires: new Date().getTime() + 100000
                    };
                    resolve(cache[url].responseBody);   
                }
                catch {
                    reject(404);
                }
            }, 1500);
        });
    }
}