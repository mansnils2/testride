﻿import * as React from 'react';
import TestdriveDashboardParent from './TestdriveDashboardParent';

export const UserTestdrives = () => {
	const query = 
		`{
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
		}`;
	return <TestdriveDashboardParent query={query} dataset={'myTestdrives'}/>;
}