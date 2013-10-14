
ThoughtWorks 2013 Sydney XConf - Presentation Code
==================================================

Content
-------

* [wcf-iis](http://github.com/jdamore/xconf-services/tree/master/wcf-iis) contains sample WCF services
* [mvc-iis](http://github.com/jdamore/xconf-services/tree/master/mvc-iis) contains sample MVC services
* [build.ps1](http://github.com/jdamore/xconf-services/blob/master/build.ps1) is the Psake build file

Bootstrap Environment
---------------------

* Install IIS7
* Get the code and run "go setupiis"


Interfaces
----------

* wcf-iis VoucherService

SOAP	vouchers			POST	http://localhost:90/wcf-iis/VoucherService.svc/Vouchers
WEB		json/{storeNumber}	GET		http://localhost:90/wcf-iis/VoucherService.svc/json/{STORENUMBER}
WEB		xml/{storeNumber}	GET		http://localhost:90/wcf-iis/VoucherService.svc/xml/{STORENUMBER}

* wcf-iis LocatorService

WEB		xml/				GET		http://localhost:90/wcf-iis/LocatorService.svc/xml/
WEB		xml/{service}		GET		http://localhost:90/wcf-iis/LocatorService.svc/xml/{SERVICE}

* mvc-iis VoucherController

WEB		{storeNumber}		GET		http://localhost:90/mvc-iis/Voucher/{STORENUMBER}
WEB		json/{storeNumber}	GET		http://localhost:90/mvc-iis/Voucher/json/{STORENUMBER}


