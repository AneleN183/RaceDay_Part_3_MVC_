✨RaceDay - Part 3 - MVC web application✨

Good morning/evening.
This README us for my Part 3 assignment for PROG6212. We have been asked to create a full stack even management system that's designed for the South African road running, walking and cycling community. 
This project is a complete ASP.NET Core MVC web application that serves as the front end for the RaceDay platform. It strictly consumes the RESTful API built in Part 2 and provides distinct, role-based interfaces for organizers and participants. 

⚠️DISCLAIMER⚠️
My Part 2 API experienced a backend runtime crash right before submission. So, to ensure I could still demonstrate my understanding of MVC architecture, REST consumption, session management and role-based UI for Part 3, I implemented a service layer mocking strategy. This allows you to login, browse events and see distinct organizer and participant interfaces exactly as they would behave with a live API. 

So, at this point since I am done with the coding of the application, I can show you what it looks like when I run the application. Since, my application crashed before submission and I did not have time to fix it, I would like to provide proof that it works. When I run my code, the first thing you see is the Login page. 

1.Login page 
<img width="1591" height="899" alt="image" src="https://github.com/user-attachments/assets/1e232ab5-c3d3-45ba-b98b-429d3442026c" />

When you click the register button at the top, this is what you'll see 
2. Register page 
<img width="1598" height="896" alt="image" src="https://github.com/user-attachments/assets/5be9bbf5-65da-4992-8d56-8715aa1d15f3" />

Now remember what I said above? I said I implemented a service layer mocking strategy that allows you to login, browse events and see distinct organizer and participant interfaces exactly as they would behave with a LIVE API. So, because I used a mock strategy, I need mock data right? So here's the mock data for you to use to also test out the roles in the application. 

Follow these steps✨
1. Click the Login button
2. Type admin@org.com and a password
3. Okay you're in,  and then click Organizer Dashboard
4. <img width="1599" height="899" alt="image" src="https://github.com/user-attachments/assets/a383be6d-6f2f-43e1-bc26-a879a6bf995d" />

5. Now, click Logout
6. Then enter user@test.com and a password
7. See, now you can see My Profile, My Enrolments and My Results, so it works!
   <img width="1591" height="898" alt="image" src="https://github.com/user-attachments/assets/ad7da428-6289-4ca5-8391-0be15bc6ec80" />


