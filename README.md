## JQDotNet

JQDotNet is a framework which is used to query JSON data using simple and flexible expressions.
It is built on .net framework 3.5.

With JQDotNet, you can do the followings:

	Query JSON data and retrieve value(s) or portion of JSON data
	Sum values in JSON data
	Take average of values in JSON data
	Retrieve count of items in JSON data
	Find maximum/minimum of values in JSON data
	
## First look

Below, you see a sample JSON.

	
	[
	  {
	    "Participants": [4,6],
	    "Title": "Happy birthday",
	    "Messages": [
	      {
	        "Sender": 4,
	        "SendDate": "2013-05-16T22:00:00+03:00",
	        "Content": "Wish you happy birthday :)",
	        "Attachments": [
	          {
	            "Title": "Cake",
	            "ItemLink": "url here",
	            "ItemSize": 90.0
	          }
	        ]
	      },
	      {
	        "Sender": 6,
	        "SendDate": "2013-05-17T00:00:00+03:00",
	        "Content": "Oh what a nice surprise for me! Thank you dear"
	      }
	    ]
	  }
	]

And, in the following lines, you see sample illustrating how JQDotNet works with this sample JSON.
	
	// The first parameter is JSON data shown above.
	// The second parameter is our query expression to get value.
	var searchResult = JSONQuery.GetValue("json data here...", "Messages[Sender = 4].Attachments[0].Title");
	// Here searchResult is set "Cake" 
	// because we want to retrieve the value of Title element of first child of Attachments array in children of Messages whose Sender equals to 4
	

