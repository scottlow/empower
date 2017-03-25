function donateResponse(response) {

}

function donate() {
    alert("Trump is Fucked");
    //  PFaN:  49468dumbnoseapps.EmpowerUp_hr4knkk4we5dp
    browser.runtime.sendNativeMessage("com.dumbnose.empowerup.donate", "message", donateResponse);
}

function displayDonateBtn() {
	if (window.location.origin === "https://twitter.com") {

		var tweets = document.querySelectorAll('.tweet')

		for (i = 0; i < tweets.length; ++i) {
			var twitterHandle = tweets[i].getAttribute('data-screen-name');

			if (twitterHandle && twitterHandle === 'realDonaldTrump') {
				var tweet = tweets[i].querySelector('.tweet-text');

				if (tweet && !tweet.fucked) {
                    var donateBtn = document.createElement("button");
                    var newContent = document.createTextNode("Fuck Trump!");
                    donateBtn.appendChild(newContent);
                    donateBtn.onclick = donate;
                    tweet.parentElement.appendChild(donateBtn);
                    tweet.fucked = true;
				}
			}
		}
	}
	else
    {
        // Chrome
        //var tweets = document.getElementsByClassName('twitter-tweet');

		var tweets = document.querySelectorAll('twitterwidget')
		for (i = 0; i < tweets.length; ++i) {

            // Chorme
            //var twitterHandle = tweets[i].shadowRoot.querySelector('.TweetAuthor-screenName');
            var twitterHandle = tweets[i].contentDocument.querySelector('.TweetAuthor-screenName');

			if (twitterHandle && twitterHandle.textContent=== '@realDonaldTrump') {

                // Chrome
                //var tweet = tweets[i].shadowRoot.querySelector('.Tweet-text');
                var tweet = tweets[i].contentDocument.querySelector('.Tweet-text');

				if (tweet) {
				}
			}
		}
	}
}

var timer;

new MutationObserver(function(mutations) {
	clearTimeout(timer);
	timer = setTimeout(displayDonateBtn, 1000);
}).observe(document.body, { childList: true, subtree: true });
