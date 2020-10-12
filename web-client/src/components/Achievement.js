import React from 'react'
const worldExportImage = require('../assets/img/certs/world export.png')

export const Achievement = () => {
    return (
        <section id="achievements">
            <div className="container col-lg-8 mx-auto text-center">
                <h2>Story so far</h2>
                <hr className="primary" />
                <p className="text-muted">
                    The Governmental authorities of Viet Nam have granted our company “Green Channel” facilities for our export and import cargo, in recognition of quality standards and the company’s good track record.
                <br>
                    </br>
                This Certification & facility is only awarded to select few export companies which are carefully audited and analized by the Board of Investment authority in Viet Nam.
            </p>
            </div>
            <div className="container-fluid text-center">
                <div className="row">
                    <div className="col-lg-12 mx-auto">
                        <img className="img-fluid" src={worldExportImage} alt="" />
                    </div>
                </div>
            </div>
        </section>
    )
}
