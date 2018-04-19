# Lets drive together!
Lets drive is a simple app that lets users log testdrives for a given vehicle in our database. In the future you'll also be able to verify drivers licenses and get more complex data from the application.

To check it out, go to https://letsdrive.azurewebsites.net and have a look around.

Pssst! It's password-protected so we have set up a semi-admin account that you guys can test around with, the login is admin@testdrives.se (fake-email, so dont send anything yeah?) and password Abc<123.

Enjoy! 

## Neat! So how do you use it?

1. Logging testdrives: input a valid swedish licenseplate (example XOT611) into the box, and watch the API tell you which car it is. Then press the now unblocked button that says 'Provkör {licenseplate}' to log a testdrive.

2. GraphQL-API: we made our own GraphQL-api, pretty neat huh? Head to https://letsdrive.azurewebsites.net/graphiql to check it out and test some queries of your own.

3. Review past customers: Head to https://letsdrive.azurewebsites.net/customers to view past customers and how many cars they have test-driven (might be a word, up for review in later release).

4. BONUS! It's all driven with Websockets, so if you log a testdrive it'll be pushed to everyone else so that they can see it. Refresh? Pfft, ain't got time for that.

## Awesome! So it's finished?
Sadly, no. There's still a couple of things left, and here's a list:

1. Log customer names, now it's just a placeholder.

2. Log customer-data and verify drivers-licenses directly from a photo.

3. Advanced searching - review past testdrives and see what's happened in your organisation.

## Technical stuff
A brief summary of how and of what this app is put together of.

### Technology used
Our app uses Entity Framework coupled with GraphQL to create a powerful backend / API. This API is now only used by our frontend which is written in React {{ with Redux! }}. Furthermore we use cool APIs like Auth0 to power our authentication and Pusher to make verything in our app all realtime!

### Structure
Yowza! This is ADVANCED so lets have a close look below.

![alt text](http://i0.kym-cdn.com/photos/images/original/001/151/543/119.jpg)

Well you've gotten this far, so you must be in it for the details. We won't tell you everything, because our API is pretty big and is WAY TOO COMPLEX to explain anyone who isn't familiar with GraphQL or Entity Framework.

But if you'd like, you can read up on GraphQL here and Entity Framework here.

But lets get down to the business of why you're here (which is probably to review our client-code). The client-code is located in the folder ClientApp, which has the following sub-folders:

#### components
These are the main focus, so pay close attention.

##### Customers
In here we have a simple component that gets customers from our graphql-api and displays them in an orderly fashion. It reloads the customers as soon as a new one is added. <- this will change in later iterations to only affect a given customer.

##### GraphQL
A simple wrapper for a GraphiQL-component which is used to test queries made to our own API.

##### Shared
Has files that are general, for example a spinner, table, navbar and a greeting-component.

##### Testdrive
This is where the magic happens, here we have the component that will do most of the heavy-lifting:

###### StartTestdrive.tsx
This component is responsible for checking whether an entered licenseplate is valid or not, preload the carmodel and make so that you can see that you are entering the right licenseplate. It also logs all the testdrives.

#### css
Contains our sites individual sass-files which we compile to create our sites css.

#### functions
Here we save basic functions, which for now is not that complex. The files here are only abstractions of simple requests made to our backend.

#### store
This is where we define our applications Redux-state.

#### subfolder store -> misc
The only global state we have for now is the navbar which stays open or closed depending on whether you leave it open or closed. This will be developed to hold submenus and which item is currently active.

... Furthermore we also have a couple of files whose scope is pretty wide.

#### boot-client.tsx
This file is basically just a large rewrite of ReactDOM.render. This is where we initialize the client-app with for example Pusher and other services.

#### boot-server.tsx
TL:DT; our server-rendering code.

#### configureStore.ts
TL:DR; configures our localstore for our persisted store and builds middleware used for hot reload in dev-environments.

#### module-class.d.ts
This file is a declaration-file for untyped components, where we enter the types ourselves.

#### routes.tsx
This file defines all the routes within our client-app.
