
interface ICacheItem {
    responseBody: object,
    expires: number,
};

const cache: Record<string, ICacheItem> = {};

export default class ApiBase {
    static getCached(url: string, conf?: object, fallback?: Object): Promise<object> {
        return new Promise((resolve, reject) => {
            if (typeof cache[url] != 'undefined') {
                if (cache[url].expires > new Date().getTime()) {
                    console.log(url, "Cache used");
                    resolve(cache[url].responseBody);
                    return;
                }
            }


            setTimeout(() => {
                try {
                    const data = fallback!;
                    cache[url] = {
                        responseBody: data,
                        expires: new Date().getTime() + 100000,
                    }
                    resolve(cache[url].responseBody);
                }
                catch {
                    reject(404);
                }
            }, 1500)

        })
    }
}