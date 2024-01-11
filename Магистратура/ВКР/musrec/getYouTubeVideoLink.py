from bs4 import BeautifulSoup
import requests
from youtube_search import YoutubeSearch

def getYouTubeLink(songName, artist):
    #youTubeLink = ""
    #baseURL = "https://www.youtube.com/results?search_query="
    result = YoutubeSearch(songName + " by " + artist, max_results=20).to_dict()
    for item in result:
        if item['url_suffix'] != '':
            return item['url_suffix']
    # try:
        # page = requests.get(baseURL + songName + " by " + artist)
        # soup = BeautifulSoup(page.content,'html.parser')
        # h3Results = soup.find(attrs={'class':'yt-simple-endpoint'})
        # print(h3Results)
        # youTubeLink = h3Results[0].find("a")['href']
        # print(youTubeLink)
        # if(youTubeLink==None):
            # getYouTubeLink(songName, artist)
        # return youTubeLink
    # except:
        # youTubeLink = getYouTubeLink(songName, artist)
        # return youTubeLink