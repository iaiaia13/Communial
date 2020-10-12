import React from 'react'

export const About = () => {
    return (
        <section className="bg-primary" id="about">
            <div className="container">
                <div className="row">
                    <div className="col-lg-4 mx-auto text-center">
                        <img id="logo-image" src="../layout/img/logo img.png" alt="" />
                    </div>
                    <div className="col-lg-8 mx-auto text-center">
                        <h2 className="section-heading text-white">We've got what you need!</h2>
                        <hr className="light" />
                        <p className="text-faded">
                            Diamond Commodity Co., Ltd is a member of a Group of family-owned companies specializing in rice.
							<br></br>
                                Located in the Mekog Delta - South West of Viet Nam, where the soft from fertilize soil, the natural aroma from tropical climate and the purity from seeds to serve our customers all over the world.
							<br></br>
                                    Our factories, with highly advanced state-of-the-art machinery and techniques for rice improvement, we have successfully gained trust and confidence from customers and supplied rice to markets throughout the world worldwide.
						</p>
                            <a className="btn btn-default btn-xl js-scroll-trigger" href="#services">Get Started!</a>
					</div>
				</div>
			</div>
		</section>
    )
}
