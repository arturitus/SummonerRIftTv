exports.handler = async (event, context) => {
    const { riotServerRegion, summonerName, tagLine } = event.queryStringParameters;

    const apiKey = process.env.API_KEY; // Accessing the API key from environment variable
    // Check if required parameters are provided
    if (!riotServerRegion || !summonerName || !tagLine) {
      return {
        statusCode: 400,
        body: JSON.stringify({ error: "Missing required parameters" })
      };
    }
  
    // Construct the URL
    const url = `https://${riotServerRegion}.api.riotgames.com/riot/account/v1/accounts/by-riot-id/${summonerName}/${tagLine}?api_key=${apiKey}`;
  
    // Return the URL as JSON
    return {
      statusCode: 200,
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({ url: url })
    };
  };
  