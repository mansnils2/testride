import * as React from 'react';
import Greeting from './../Shared/Greeting';
import Spinner from './../Shared/Spinner';
import { Table } from './../Shared/Table';
import graphCall from '../../functions/GraphCall';

export class UserTestdrives extends React.Component<{}, { hasError: boolean, isLoading: boolean, testdrives: any[] }> {
    constructor() {
        super();
        this.state = {
            hasError: false,
            isLoading: true,
            testdrives: []
        };
    }

    componentDidMount() {
        const body = {
            query: `{
                        testdrives {
                            id
                            car {
                              licenseplate
                              carName
                            }
                          }
					}`
        };
        graphCall(
            body,
            (result) => this.setState({ testdrives: result.data.testdrives, isLoading: false }),
            () => this.setState({ hasError: true, isLoading: false }));
    }

    render() {
        return <div className="mt-3">
            <p className="h5">Översikt över dina senaste 10 provkörningar</p>
            <hr className="mb-0 row" />
            <Table rows={[]} />
            <div className="mb-5" />
        </div>;
    }
}