import Link from "next/link";
import React from "react";

const Header = () => {
	return (
		<header className='bg-purple-800 shadow-sm'>
			<div className='container text-white py-4 flex gap-4 items-center'>
				<Link href='/'>
					<a className='text-4xl font-mono'>LongRocks</a>
				</Link>
			</div>
		</header>
	);
};

export default Header;
