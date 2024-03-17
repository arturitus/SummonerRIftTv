const axios = require('axios');

// Function to retrieve active games
const getActiveGames = async (region, summonerId, apiKey) => 
{
  const url = `https://${region}.api.riotgames.com/lol/spectator/v4/active-games/by-summoner/${summonerId}?api_key=${apiKey}`;
  return fetchData(url);
};

// Function to retrieve summoner by name
const getSummonerByName = async (region, summonerName, apiKey) => 
{
  const encodedSummonerName = encodeURIComponent(summonerName);
  const url = `https://${region}.api.riotgames.com/lol/summoner/v4/summoners/by-name/${encodedSummonerName}?api_key=${apiKey}`;
  return fetchData(url);
};

// Helper function to fetch data from API
const fetchData = async (url) => 
{
  try 
  {
    const response = await axios.get(url);
    return response.data;
  } 
  catch (error)
  {
    console.error(`Error fetching data: ${error.message}`);
    throw error;
  }
};

module.exports = { getActiveGames, getSummonerByName };