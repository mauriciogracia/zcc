import React from 'react';
import { useState } from 'react';
import './App.css';



function App() {
    const [zipFrom, setOrig] = useState('');
    const [zipDest, setDest] = useState('');
    //const []

    function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        let apiURL = `https://localhost:7242/DistanceCalculation?zipOrig=${zipFrom}&zipDest=${zipDest}`
        console.log(`call web api ${apiURL}`);

        fetch(apiURL).then(res => res.json())
                .then(
                    (result) => {
                        console.log(result);
                        /*this.setState({
                            employees: result
                        });
                        */
                    }
                );
    }

    return (
    <div className="App">
            <form onSubmit={handleSubmit}>
          <h3>Zip Code Distanance Calculation - React</h3>
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
