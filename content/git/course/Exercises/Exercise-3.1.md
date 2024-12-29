# Pull Request with policy

## **DO 1**

Clone [NUnit.Practices](https://github.com/OsirisTerje/NUnit.Practices)

Remove the remote

Create a new repo on your Github account

Invite your team members to your repo  (at least a couple of them)

*Hint:  Settings/Manage Access -> "Invite a collaborator" button*

Assign the local repo to this new remote repo, and push all

Verify that an Action is running

## **DO 2**  Set up a pull request policy

You are going to protect the master branch.  This means that to update this branch everyone have to go through your pull request and fulfill the requirements in the PR policy.

On the repo site:

Go to Settings, choose Branches

The second section there, choose "Add rule"

Give it a nice name that you easily can recognize, like "Practices.PR".  

Check the "Require pull request reviews before merging".

Then choose "Require status checks to pass before merging"

It should find the status check for the build, check this.

Also check the "Include administrators"

## **DO 3** Raise a pull request

In your local repo, create a new branch, and make a change, which you then add and commit.

Publish the branch to the remote.

Raise a pull request from the repo web site for the branch you just published.

You can add a fair comment on the PR to help the reviewer.  Also, request a reviewer from one of those you added to your repo above. 

Ask a team member to do a code review.  

You will get some feedback, fix whatever that is, and when the review is finished, and all builds are green, Merge the PR.

### Questions

You should see 3 checks, all of them build checks.  Explain what they are.

Why are only one run for the pull request itself?

What is it building?

## **DO 4** Comment on others pull requests

You have been asked to review someone elses [on your team] PR.

Go to the **Files Changes** tab

You can give a general comment directly there, using the Review Changes button.

You can also comment directly to the changes, hover over a changed line, and you see a plus sign, which when you press allow you to comment on that line, and then start a review directly from there.

As you will have multiple reviews, try the different options, and engage in a conversation with your peer.

End up with finishing your review, hopefully you'll approve them :-)

## **Discussion**

There are multiple other checks you can add.

Discuss a few that you would think could benefit the organisation, and help in ensuring quality is raised.

Hint:  Check out the github apps.  Try e.g. WIP,  and check out the possible actions you can add to your build

