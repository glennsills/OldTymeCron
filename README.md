# Old Tyme Cron
I started working on this project for fun. There was a discussion at work as to how we should launch scheduled tasks in our environment. That environment was a Microsoft Service Fabric cluster, with RPC based microservices ideally performing the business logic, RESTFUL APIs prroviding application integration access and Ocelot Gateway performing the service ingress functionality. We wanted a convenient way to schedule tasks that hit the microservices and did stuff. These services were not scheduled by end users, they were things like recurring billing reports and the like. So I said, we should be able to use generic host functionality in .NET and make each scheduled task inherit from BackgroundTask. Sure, Hangfire.IO is great and there is Quartz.net and probably other packages that can  be used for this purpose, but it seemed to me that if you just wanted to run some code every Friday at 11:00 AM, it should be no harder than a CRON job was on Unix back in the day.  What you see in this repo is my attempt to perform that functionality in the most direct and simple way. I am in no way trying to replace the functionality that comes from other fine packages. I'm just trying to prove to myself that for something simple they are not needed and maybe more trouble than they are worth. You will find this code in the _main_ branch. This version of the program comes with a couple of very simple tasks that simply write "Hello world" to the console.

## Yeah But What About Scheduling Tasks in the Cloud?
I figure I'll create a Kubernetes cluster that will run under Docker for Windows. I'll do this in the Kubernetes branch. I'm not sure how far I want to take this yet. I can make the cron app a reduntant service to make it more reliable, but that would make it a bit more complicated. TBD. Anyway, this solution will be in the _kubernetes_ branch.
### Fun Side Trip
I decided to try out dotnet-openapi to create the client proxy to the TopNews API. *Add more detail here later*.

## Yeah But What About Monitoring?
I am pretty sure that I am going to be able to handle this with some out of the box logging that sinks to a cloud based log store like Elastic and then build a dashboard. My priority here is simplicity and I want to get a free container from hub.docker.com - because I am cheap. I'll call this branch _monitoring_. It will be based on the _kubernetes_ branch.

## Trivial App for Demonstration Purpose
The _kubernetes_ and _monitoring_ branches require bit more functionality for demostrationg purposes. The **TopNews** program provides a very simple CRUD API for top news stories retrieved from HackNews. It will store this information SQLLite. So the Kubernetes cluster in the _kubernetes_ branch contains two services, 1 for the OldTymeCron app, and one for the TopNews app. The _monitoring_ branch contains additional services for storing logs and creating the dashboard (TBD)



