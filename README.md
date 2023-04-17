0 Simple Architecture Diagram
1. How to run Console application (include screen shot)
	-NET version
	- input validation (when empty input it asks again...)

	Steps
	- docker pull mongo
	- docker run -d -p 27017:27017 --name cities-mdb mongo
	- docker exec -it cities-mdb /bin/bash
	- mongosh
	- use clients-db
	- db.createCollection('Cities')
2. How to run Website (react asp.net)
	- React + Netversion