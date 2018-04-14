import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';

export default class Home extends React.Component<RouteComponentProps<{}>, {}> {
    render() {
        return <div>
            <h1>Hello, world!</h1>
        </div>;
    }
}
