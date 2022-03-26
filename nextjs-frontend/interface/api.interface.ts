export interface Panel {
	model: string;
	cost: number;
	efficiency: number;
	power: number;
	length: number;
	width: number;
	weight: number;
}

export interface Installer {
	id: string;
	callOutCost: number;
	costPerPanel: number;
}

export interface Tariff {
	name: string;
	price: number;
	minimumFeedAmount: number;
	maximumFeedAmount: number;
	expiry: string;
	expiredPrice: number;
}

export interface FittedPanels {
	panel: Panel;
	count: number;
	totalCost: number;
	totalPower: number;
	totalUsefulPower: number;
}

export interface FittedInstaller {
	installer: Installer;
	totalPrice: number;
}

export interface FittedTariff {
	tariff: Tariff;
	averageFeedAmounts: number[];
	averageRevenues: number[];
	averageExpiredRevenues: number[];
}

export interface EstimatedQuote {
	averageProfits: number[];
	averageDailyProfit: number;
	daysToBreakEven: number;
	installer: FittedInstaller;
	panels: FittedPanels;
	tariff: FittedTariff;
	totalPrice: number;
}
