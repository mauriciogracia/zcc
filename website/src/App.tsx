import React from 'react';
import { useState } from 'react';
import './App.css';



function App() {
    const [zipFrom, setOrig] = useState('');
    const [zipDest, setDest] = useState('');

    function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        console.log(`call web api ${zipFrom} ${zipDest}`);
    }

    return (
    <div className="App">
          <form onSubmit={handleSubmit}>
              <label>
                  Zip From:
                    <input type="text" name="zipFrom" id="zipFrom" onChange={(event) =>
                        setOrig(event.target.value)
                    } />
              </label><br />
              <label>
                  Zip Destination:
                    <input type="text" name="zipDest" id="zipDest" onChange={(event) =>
                        setDest(event.target.value)
                    } />
              </label><br />
              <input type="submit" value="Submit" />
          </form>
    </div>
  );
}

export default App;
