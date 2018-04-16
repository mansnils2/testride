import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import { StartTestdrive } from './Testdrive/StartTestdrive';
import { UserTestdrives } from './Testdrive/UserTestdrives';

export default class Home extends React.Component<RouteComponentProps<{}>, {}> {
    render() {
        return <div>
            <StartTestdrive />
            <UserTestdrives />
        </div>;
    }
}
