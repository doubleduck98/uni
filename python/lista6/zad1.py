from bs4 import BeautifulSoup, SoupStrainer
import urllib.request
from urllib.parse import urljoin
import re


def find_python(url):
    try:
        url_contents = urllib.request.urlopen(url).read()
    except urllib.error.HTTPError as e:
        print(f'{e} ({url})')
        raise
    except:
        print(f'nieznany błąd podczas łączenia się z {url}')
        raise
    finally:
        # For example r'\bfoo\b' matches 'foo', 'foo.', '(foo)', 'bar foo baz' but not 'foobar' or 'foo3'
        py = re.compile(r'\bpython\b', re.IGNORECASE)
        site = BeautifulSoup(url_contents, features='html.parser')
        return len(py.findall(str(site.getText)))


def gather_urls(current_url, distance, urls):
    if distance < 0:
        return

    try:
        site_contents = urllib.request.urlopen(current_url).read()
    except urllib.error.HTTPError as e:
        print(f'{e} ({current_url})')
        return
    except:
        print(f'nieznany błąd podczas łączenia się z {current_url}')
        return
    finally:
        urls.add(current_url)
        for header in BeautifulSoup(site_contents, parse_only=SoupStrainer('a'), features='html.parser'):
            if header.has_attr('href'):
                if not str(header['href']).startswith(r'\#') and header['href'].strip() != '':
                    url = urljoin(current_url, str(header['href']))
                    if url not in urls:
                        urls.add(url)
                        gather_urls(url, distance-1, urls)


def crawl(base_url, distance, action):

    urls = set()
    print('gathering URLs')
    gather_urls(base_url, distance, urls)
    print(f'found {len(urls)} URLs')

    for url in urls:
        try:
            res = find_python(url)
        except:
            continue
        finally:
            yield (url, res)


strona_startowa = 'https://pl.wikipedia.org/wiki/Python'


for x in crawl(strona_startowa, 2, find_python):
    print(x)
