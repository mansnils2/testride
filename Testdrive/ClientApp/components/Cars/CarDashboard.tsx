import * as React from 'react';
import Greeting from './../Shared/Greeting';
import Spinner from './../Shared/Spinner';
import { Table } from './../Shared/Table';
import graphCall from '../../functions/GraphCall';
import * as moment from 'moment';
import Pusher from 'react-pusher';

export class UserTestdrives extends React.Component<{}, { hasError: boolean, isLoading: boolean, testdrives: any[] }> {
	constructor() {
		super();
		this.state = {
			hasError: false,
			isLoading: true,
			testdrives: []
		};

		this.addIncomingTestdrive = this.addIncomingTestdrive.bind(this);
	}

	componentDidMount() {
		const body = {
			query: `{
                        myTestdrives {
							id
							timestamp
							car {
								licenseplate
								carName
							}
							customer {
								name
							}
						}
					}`
		};
		graphCall(
			body,
			(result) => this.setState({ testdrives: result.data.myTestdrives, isLoading: false }),
			() => this.setState({ hasError: true, isLoading: false }));
	}

	render() {
		return this.state.isLoading ? <Spinner message="Hämtar provkörningar" /> : this.startTestdriveRender();
	}

	startTestdriveRender() {
		return this.state.hasError ? <Greeting title="Det uppstod ett fel" text="Det uppstod tyvärr ett fel medan dina provkörningar sammanställdes." /> : this.renderTestdrives();
	}

	addIncomingTestdrive(data) {
		const testdrives = this.state.testdrives;
		testdrives.unshift(data);
		this.setState({ testdrives: testdrives });
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
						value: moment(t.timestamp).format('YYYY-MM-DD hh:mm')
					}
				]
		});

		return <div>
			<Pusher channel="testdrives" event="new-testdrive" onUpdate={this.addIncomingTestdrive} />
			<Table rows={testdrives} />
		</div>;
	}
}