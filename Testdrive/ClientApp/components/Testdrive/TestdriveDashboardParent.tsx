import * as React from 'react';
import Greeting from './../Shared/Greeting';
import Spinner from './../Shared/Spinner';
import { Table } from './../Shared/Table';
import graphCall from '../../functions/GraphCall';
import * as moment from 'moment';
import Pusher from 'react-pusher';
import date from 'date-and-time';

export default class TestdriveDashboardParent extends React.Component<{ query: string, dataset: string}, { hasError: boolean, isLoading: boolean, testdrives: any[] }> {
	constructor() {
		super();
		this.state = {
			hasError: false,
			isLoading: true,
			testdrives: []
		};

	    this.setTestdrives = this.setTestdrives.bind(this);
        this.getNewTestdrives = this.getNewTestdrives.bind(this);
	}

    setTestdrives(result) {
        this.setState({ testdrives: result.data[this.props.dataset], isLoading: false });
    }

	componentDidMount() {
		graphCall(
			{ query: this.props.query },
            this.setTestdrives,
			() => this.setState({ hasError: true, isLoading: false }));
    }

    getNewTestdrives() {
        graphCall(
            { query: this.props.query },
            this.setTestdrives,
            console.log);
    }

	render() {
		return this.state.isLoading ? <Spinner message="Hämtar provkörningar" class="mt-5 text-center"/> : this.startTestdriveRender();
	}

	startTestdriveRender() {
		return this.state.hasError ? <Greeting title="Det uppstod ett fel" text="Det uppstod tyvärr ett fel medan dina provkörningar sammanställdes." /> : this.renderTestdrives();
    }

	renderTestdrives() {
		const testdrives = this.state.testdrives.map((t) => t = {
			key: t.id,
			items:
				[
					{
						key: `reg-${t.id}`,
						description: 'Bil',
						value: t.car.licenseplate + ' - ' + t.car.carName
					},
					{
						key: `customer-${t.id}`,
						description: 'Kund',
						value: t.customer ? t.customer.name : 'Kundens info saknas'
					},
					{
						key: `timestamp-${t.id}`,
						description: 'Tidpunkt',
                        value: date.format(moment(t.timestamp * 1000).toDate(), 'YYYY-MM-DD HH:mm')
					}
				]
		});

		return <div className="position-relative">
            <Pusher channel="testdrives" event="new-testdrive" onUpdate={this.getNewTestdrives} />
			<Table rows={testdrives} />
        </div>;
	}
}