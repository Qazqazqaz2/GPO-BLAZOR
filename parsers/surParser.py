import requests
from bs4 import BeautifulSoup

res = ''

def get_surname(name, surname, patronymic):
    url = "https://surnameonline.ru/inflect.php"
    headers = {
        "Accept": "text/html, */*; q=0.01",
    "Accept-Language": "ru,en;q=0.9",
    "Content-Type": "application/x-www-form-urlencoded; charset=UTF-8",
    "Sec-CH-UA": "\"Chromium\";v=\"118\", \"YaBrowser\";v=\"23.11\", \"Not=A?Brand\";v=\"99\", \"Yowser\";v=\"2.5\"",
    "Sec-CH-UA-Mobile": "?1",
    "Sec-CH-UA-Platform": "\"Android\"",
    "Sec-Fetch-Dest": "empty",
    "Sec-Fetch-Mode": "cors",
    "Sec-Fetch-Site": "same-origin",
    "X-Requested-With": "XMLHttpRequest"
    }
    data = {
        'name': name,
        'surname': surname,
        'patronymic': patronymic
    }
    
    try:
        response = requests.post(url, headers=headers, data=data)
        response.raise_for_status()  # Raise an error for bad responses
        soup = BeautifulSoup(response.text, 'html.parser')
        get_text_nodes(soup)
        print(res)
    except requests.exceptions.RequestException as error:
        print('There has been a problem with your request operation:', error)

def get_text_nodes(soup):
    global res
    text_nodes = []

    def walk_nodes(node):
        for elem in node.contents:
            if elem.name is None:  # Text node
                if len(text_nodes) == 0:
                    res += str(elem) + ": "
                elif len(text_nodes) == 1:
                    res += str(elem) + "\n"
                text_nodes.append(str(elem))
            elif elem.name != "p":
                walk_nodes(elem)

    # Start walking from the <body> element
    walk_nodes(soup.body)

get_surname("Артём", "Ермолов", "Артурович")
