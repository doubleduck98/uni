from bs4 import BeautifulSoup, SoupStrainer
import urllib.request
from urllib.parse import urljoin
import re


def find_python(url):
    try:
        url_contents = urllib.request.urlopen(url).read()
    except:
        print(f'nie mozna połączyć się ze stroną: {url}')
        return 'błąd łączenia się ze stroną'
    py = re.compile('python')
    site = BeautifulSoup(url_contents, features='html.parser')
    return len(py.findall(str(site.contents)))


def gather_urls(current_url, distance, urls):
    if distance < 0:
        return

    try:
        site_contents = urllib.request.urlopen(current_url).read()
    except:
        print(f'nie mozna połączyć się ze stroną: {current_url}')
        return

    urls.add(current_url)
    for header in BeautifulSoup(site_contents, parse_only=SoupStrainer('a'), features='html.parser'):
        if header.has_attr('href'):
            if header['href'] != '#' and header['href'].strip() != '':
                url = urljoin(current_url, str(header['href']))
                if url not in urls:
                    urls.add(url)
                    print(url)
                    gather_urls(url, distance-1, urls)
    
    return urls


def crawl(base_url, distance, action):

    urls = set()
    gather_urls(base_url, distance, urls)

    for url in urls:
        yield (url, find_python(url))


strona_startowa = 'https://pl.wikipedia.org/wiki/Specjalna:Losowa_strona'

for x in crawl(strona_startowa, 2, find_python):
    print(x)
