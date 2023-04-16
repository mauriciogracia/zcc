import React, { Component } from 'react';
import { Layout } from './components/Layout';
import './custom.css';

export default class App extends Component {
    static displayName = App.name;

    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(e) {
        e.preventDefault();
        console.log('form sent');
    }

    render() {
        return (

            <Layout>
                <form onSubmit={this.handleSubmit}>
                    <label>
                        Zip From:
                        <input type="text" name="zipFrom" />
                    </label><br/>
                    <label>
                        Zip Destination:
                        <input type="text" name="zipDest" />
                    </label><br/>
                    <input type="submit" value="Submit" />
                </form>
            </Layout>
        );
    }
}
