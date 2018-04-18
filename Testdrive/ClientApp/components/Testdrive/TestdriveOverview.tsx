import * as React from 'react';
import TestdriveDashboardParent from './TestdriveDashboardParent';

export const TestdriveOverview = () => {
	const query =
		`{
			testdrives(include: "Car,Customer") {
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
		}`;
	return <TestdriveDashboardParent query={query} dataset={'testdrives'} />;
}