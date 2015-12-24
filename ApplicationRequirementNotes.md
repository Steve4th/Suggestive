***Suggestive Requirements Notes***

The web site will manage and display a list of feedback items 
    (Item name TBC - user reports/ enhancements/ suggestions/ feedback item ?)

**Feedback Items**
Each feedback item needs to include:

- Subject/title
- Description
- Originator (user who created it)
- Date created
- Date last updated
- Current score
- Status (new/declined/under review/committed/delivered
- Tags
- Comments. Each comment needs:
	- author
	- comment content
	- date added
	
    Comments can only be added by authenticated/logged in users

**Creating a feedback item**

- Enter details of feedback item in a stand alone screen
- The user must be authenticated to create an item
- Tags are user definable and can be selected 
- All items given status of new

**Listing Feedback Items**

- Paged view of items
- sort by most voted by default
- Alow sort order to be changed to sort by date created, date updated or current score
- Provide a status filter
- Provide paging of results. 10 to a page is a good start

**User details**

- App accessible anonymously
- User can register using alt login sources Google, Twitter, Live ID
- Only need a user name and email address for registration. 
- Optional fields for telephone number if willing to be contacted about items

**Product Owner/Team Users**

- can change the status of a feedback item
- can hide comments that are inappropriate
- Can see a list of the highest voted items 
- can see a list of the most active users (used votes/ entered feedback)

**System Admin Users**

- Can remove items
- Can remove comments
- Can lock a user out

**My Feedback screen**

- List items I have created
- List items I have voted for
- User must be authenticated/logged in to see the My Feedback screen
- available to all users

**Voting:**

- Each user gets 10 votes to be allocated. 
- A user can assign 1,2 or 3 votes to a feedback item. 
- Once all the users votes are allocated they must un-allocate some of them to assign them to another item
- A user can change/remove their vote on an item at any point.
- A user must be authenticated/logged in to vote
