import React from 'react';
import './App.css';


type Values = {
    name: string,
    email: string,
    age: string,
}

function App() {
    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        console.log('form sent');
    }
    return (
        <div className="App">
            <header className="App-header">
                <form onSubmit={(e) => handleSubmit(e)}>
                    <label>
                        Name:
                        <input type="text" name="name" />
                    </label>
                    <input type="submit" value="Submit" />
                </form>
            </header>
        </div>
    );
}

export default App;
