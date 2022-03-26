import { EstimatedQuote } from "../interface/api.interface";

export interface GetQuotesBody {
	roofLength: string;
	roofWidth: string;
	averageConsumption: string;
	electricityCost: string;
	budget: string;
}

export const getQuotes = async (
	body: GetQuotesBody,
	callback?: (quotes: EstimatedQuote[]) => void
) => {
	// to be used for development using self signed certificates
	process.env.NODE_TLS_REJECT_UNAUTHORIZED = "0";
	const res = await fetch("https://localhost:7170/SolarPanel", {
		method: "POST",

		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify(body),
	});

	try {
		const quotes = await res.json();
		callback && callback(quotes);
		return quotes as EstimatedQuote[];
	} catch (err) {
		console.error("Could not parse response", err);
	}
};
