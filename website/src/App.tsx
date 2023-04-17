import React from 'react';
import './App.css';


function handleSubmit(e:any) {
    e.preventDefault();
    console.log('The Console app calculation logic should be a WEB API to be consumed here');
}

function App() {
  return (
    <div className="App">
          <form onSubmit={handleSubmit}>
              <label>
                  Zip From:
                  <input type="text" name="zipFrom" />
              </label><br />
              <label>
                  Zip Destination:
                  <input type="text" name="zipDest" />
              </label><br />
              <input type="submit" value="Submit" />
          </form>
    </div>
  );
}

export default App;
