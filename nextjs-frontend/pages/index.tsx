import type { NextPage } from "next";
import Header from "../components/Header";

const Home: NextPage = () => {
	return (
		<>
			<Header />
			<main className='container py-8'>
				<form
					action='/quotes'
					className='flex flex-col gap-8 max-w-lg mx-auto'>
					<div>
						<h1 className='text-3xl font-bold text-gray-800 mb-4'>
							House Specification
						</h1>
						<p>Please enter your house details</p>
					</div>
					<div className='input-group'>
						<div>
							<label htmlFor='roofLength'>Roof Length (m)</label>
							<input
								name='roofLength'
								type='number'
								step='any'
								required
							/>
						</div>
						<div>
							<label htmlFor='roofWidth'>Roof Width (m)</label>
							<input
								name='roofWidth'
								type='number'
								step='any'
								required
							/>
						</div>
					</div>

					<div>
						<label htmlFor='averageConsumption'>
							Average Daylight Consumption (kWh)
						</label>
						<input
							name='averageConsumption'
							type='number'
							step='any'
							placeholder="e.g. '8.91'"
							required
						/>
					</div>

					<div>
						<label htmlFor='electricityCost'>
							Electricity Cost (£/kWh)
						</label>
						<input
							name='electricityCost'
							type='number'
							step='any'
							defaultValue={0.073}
							required
						/>
					</div>

					<div>
						<label htmlFor='budget'>Budget (£)</label>
						<input
							name='budget'
							type='number'
							step='any'
							placeholder="e.g. '10,000'"
							required
						/>
					</div>

					<button className='text-white font-semibold bg-purple-700 hover:bg-purple-800 rounded p-4 mt-8'>
						Get Quotes Now
					</button>
				</form>
			</main>
		</>
	);
};

export default Home;
