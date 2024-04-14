import React, { useState } from 'react';

function TestGet() {
    const [apiResponse, setApiResponse] = useState(null);

    const fetchData = async () => {
        try {
            const response = await fetch('https://localhost:7072/api/authentication');
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

export default TestGet