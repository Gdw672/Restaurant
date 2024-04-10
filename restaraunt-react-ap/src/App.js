import React, { useState } from 'react';

function App() {
  const [apiResponse, setApiResponse] = useState(null);

  const fetchData = async () => {
    try {
      const response = await fetch('http://localhost:5115/api/sample');
      const data = await response.json();
      setApiResponse(data);
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };

  return (
      <div>
        <button onClick={fetchData}>Fetch Data</button>
        {apiResponse && (
            <pre>{JSON.stringify(apiResponse, null, 2)}</pre>
        )}
      </div>
  );
}

export default App;