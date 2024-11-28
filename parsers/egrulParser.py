import requests
import logging

# Настройка логирования
logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

def logger_connection(func):
    async def wrapper(*args, **kwargs):
        data, status = await func(*args, **kwargs)
        if status in [404, 504, 500]:
            logger.error(f"Ошибка соединения. Статус: {status}")
        else:
            if isinstance(data, str):
                logger.info(f"Запрос ключа прошёл. Ключ: {data}")
            elif isinstance(data, list):
                logger.info(f"Запрос данных прошёл. Кол-во элементов: {len(data)}")
        return data
    return wrapper

class Parser:
    def __init__(self, name):
        self.domain = 'https://egrul.nalog.ru/'
        self.headers = {
             'Accept': 'application/json, text/javascript, */*; q=0.01',
    'Accept-Language': 'ru,en;q=0.9',
    'Connection': 'keep-alive',
    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8',
    'Cookie': 'uniI18nLang=RUS; _ym_uid=1708254721451591261; _ym_d=1708254721; _ym_isad=2; _ym_visorc=b; JSESSIONID=B2CDBEFEB0DBE90895953A48B087B43E',
    'Referer': 'https://egrul.nalog.ru/index.html',
    'User-Agent': 'Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Mobile Safari/537.36',
    'X-Requested-With': 'XMLHttpRequest',
    'sec-ch-ua': '"Not_A Brand";v="8", "Chromium";v="120", "YaBrowser";v="24.1", "Yowser";v="2.5"',
    'sec-ch-ua-mobile': '?1',
    'sec-ch-ua-platform': '"Android"'
        }
        self.data = {
            'vyp3CaptchaToken': '',
            'page': '',
            'query': name,
            'region': '',
            'PreventChromeAutocomplete': '',
        }

    @logger_connection
    async def get_key(self):
        response = requests.post(self.domain, json=self.data, headers=self.headers)
        status = response.status_code
        key = response.json().get("t")
        return key, status

    @logger_connection
    async def get_data(self):
        key, _ = await self.get_key()
        result_url = f"{self.domain}search-result/{key}"
        response = requests.get(result_url)
        status = response.status_code
        data = response.json().get("rows", [])
        return data, status

async def main():
    n1 = Parser("ТГУ")
    await n1.get_data()

if __name__ == "__main__":
    import asyncio
    asyncio.run(main())