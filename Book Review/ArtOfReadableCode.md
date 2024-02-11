# The Art of Readable Code: 
## Chapter 4: Aesthetics
---
## Introduction
- The aesthetics of code focuses on how the code appears on the screen.
- Programmers spend more time **looking at code** than **writing code**.
- Therefore, it is necessary that the programmer reading the code doesn't get frustrated or confused because of how the code looks.
- Good source code should be "easy on the eyes", like a well-designed magazine.

### Principles

There are 3 main principles of good aesthetics in code:
1. Consistent layout with patterns the reader can get used to.
2. Make similar code look similar
3. Group related lines of code into blocks
---
## Common Practices

### 1. Rearrange Line Breaks to Be Consistent and Compact
Consider the example of a Java code to evaluate how your program behaves under various
network connection speeds. 

There is a 'TCPSimulator' that takes in 4 parameters: 
1. Kbps
2. Latency
3. Jitter
4. Packet Loss

Suppose 3 instances of TCPSimulator are required. Consider the below code:
```
public class PerformanceTester {
    public static final TcpConnectionSimulator wifi = new TcpConnectionSimulator(
        500, /* Kbps */
        80, /* millisecs latency */
        200, /* jitter */
        1 /* packet loss % */);

    public static final TcpConnectionSimulator t3_fiber =
        new TcpConnectionSimulator(
            45000, /* Kbps */
            10, /* millisecs latency */
            0, /* jitter */
            0 /* packet loss % */);

    public static final TcpConnectionSimulator cell = new TcpConnectionSimulator(
        100, /* Kbps */
        400, /* millisecs latency */
        250, /* jitter */
        5 /* packet loss % */);
}
```

The problem we see with this code is that we see an inconsistency of the pattern which draws our attention to the **t3_fiber** instance of TCPSimulator. Also we have repeated code which makes the code look really long. The pattern gets disrupted at t3_fiber because of the character limit for the line which makes the rest of the statement of the code go to the next line.

So after cleaning up the code, we have the below code:

```
public class PerformanceTester {
    // TcpConnectionSimulator(throughput, latency, jitter, packet_loss)
    //                           [Kbps]     [ms]    [ms]    [percent]

    public static final TcpConnectionSimulator wifi =
        new TcpConnectionSimulator(500,      80,    200,        1);

    public static final TcpConnectionSimulator t3_fiber =
        new TcpConnectionSimulator(45000,    10,    0,          0);

    public static final TcpConnectionSimulator cell =
        new TcpConnectionSimulator(100,      400,   250,        5);
}
```
This gives the code a tabular look and is vertically more compact. Also, the line breaks were used to make the style pattern consistent. the declarations of the instances were all made in 2 lines instead to cover up the line wrapping which occured for t3_fiber.


### 2. Use Methods to Clean Up Irregularity
Here, we improve the readability of the code using **Helper Functions**. These helper functions hide away the details of how things work in order to present a neat code, as well as overcome the issue of code repeated code.

Example:

Without Helper:
```
DatabaseConnection database_connection;
string error;
assert(ExpandFullName(database_connection, "Doug Adams", &error)
 == "Mr. Douglas Adams");
assert(error == "");
assert(ExpandFullName(database_connection, " Jake Brown ", &error)
 == "Mr. Jacob Brown III");
```
We can create a helper function as shown below:
```
CheckFullName("Doug Adams", "Mr. Douglas Adams", "");
CheckFullName(" Jake Brown ", "Mr. Jake Brown III", "");

void CheckFullName(string partial_name, string expected_full_name, string expected_error) 
{
 // database_connection is now a class member
 string error;
 string full_name = ExpandFullName(database_connection, partial_name, &error);
 assert(error == expected_error);
 assert(full_name == expected_full_name);
}
```
Here, the assert and ExpanFullName functions have been hidden away within the CheckFullName function, and there is no need to repeat the function calls of these two functions. Instead to add more function calls, we only need to call one function, i.e. the CheckFullName function.


### 3. Use Column Alignment When Helpful
Straight edges and columns make it easier to scan through the code. Here is an example:
```
# Extract POST parameters to local variables
    details = request.POST.get('details')
    location = request.POST.get('location')
    phone = equest.POST.get('phone')
    email = request.POST.get('email')
    url = request.POST.get('url')
```
after cleaning:
```
# Extract POST parameters to local variables
    details  = request.POST.get('details')
    location = request.POST.get('location')
    phone    = equest.POST.get('phone')
    email    = request.POST.get('email')
    url      = request.POST.get('url')
```
In this example we also see that there's a typo for request in the third line. Using column alignment can help spot typos more easily. Similarly we can use for repetitve method calling where we pass arguements. If we align them like how we did above, we can easily spot if there have been typos or missing values in the arguements.


### 4. Pick a Meaningful Order, and Use It Consistently
There are cases where the order of the code doesn't affect the correctness of the code. Yet it is important to keep a meaningful order, and stick to it to avoid confusion and to make typos more visible.

For example:
```
details = request.POST.get('details')
location = request.POST.get('location')
phone = request.POST.get('phone')
email = request.POST.get('email')
url = request.POST.get('url')
```

In such situations, it is a good practice to order them is some meaningful way, like accesing the fields in the same order as in the HTML form for the above code. 

After cleaning, it may look like:
```
details  = request.POST.get('details')
phone    = request.POST.get('phone')
email    = request.POST.get('email')
location = request.POST.get('location')
url      = request.POST.get('url')
```
Here, we first took details, then the phone number, followed email and location, and finally the url.


### 5. Organize Declarations into Blocks
The brain naturally thinks in terms of groups and hierarchies.

For example:

The below code shows a class with function declarations all put in one place together.
```
class FrontendServer {
 public:
  FrontendServer();
  void ViewProfile(HttpRequest* request);
  void OpenDatabase(string location, string user);
  void SaveProfile(HttpRequest* request);
  string ExtractQueryParam(HttpRequest* request, string param);
  void ReplyOK(HttpRequest* request, string html);
  void FindFriends(HttpRequest* request);
  void ReplyNotFound(HttpRequest* request, string error);
  void CloseDatabase(string location);
  ~FrontendServer();
};
```
The problem here is that it overwhelms the reader. We can make it better by splitting them into groups of similar functions instead of a single giant block. 

after cleaning:
```
class FrontendServer {
 public:
    FrontendServer();
    ~FrontendServer();

    // Handlers
    void ViewProfile(HttpRequest* request);
    void SaveProfile(HttpRequest* request);
    void FindFriends(HttpRequest* request);

    // Request/Reply Utilities
    string ExtractQueryParam(HttpRequest* request, string param);
    void ReplyOK(HttpRequest* request, string html);
    void ReplyNotFound(HttpRequest* request, string error);

    // Database Helpers
    void OpenDatabase(string location, string user);
    void CloseDatabase(string location);
};
```
After reading the cleaned code, the reader can better understand the categories of functions in the class.


### 6. Break Code into “Paragraphs”
In written text, we split the content into paragraphs to group similar ideas, and to provide a visual "stepping stone" to the reader to help him/her understand better. 

This can be really helpful when used within large functions to visualise the steps within the function to understand its working.

For example:
```
# Import the user's email contacts, and match them to users in our system.
# Then display a list of those users that he/she isn't already friends with.
def suggest_new_friends(user, email_password):
    friends = user.friends()
    friend_emails = set(f.email for f in friends)
    contacts = import_contacts(user.email, email_password)
    contact_emails = set(c.email for c in contacts)
    non_friend_emails = contact_emails - friend_emails
    suggested_friends = User.objects.select(email__in=non_friend_emails)
    display['user'] = user
    display['friends'] = friends
    display['suggested_friends'] = suggested_friends
    return render("suggested_friends.html", display)
```
after cleaning:
```
def suggest_new_friends(user, email_password):

    # Get the user's friends' email addresses.
    friends = user.friends()
    friend_emails = set(f.email for f in friends)

    # Import all email addresses from this user's email account.
    contacts = import_contacts(user.email, email_password)
    contact_emails = set(c.email for c in contacts)

    # Find matching users that they aren't already friends with.
    non_friend_emails = contact_emails - friend_emails
    suggested_friends = User.objects.select(email__in=non_friend_emails)

    # Display these lists on the page.
    display['user'] = user
    display['friends'] = friends
    display['suggested_friends'] = suggested_friends
    return render("suggested_friends.html", display)
```
As we can see, breaking the code into paragraphs helps to 

---
## Personal Style versus Consistency
There are some aesthetic choices that just boil down to personal style. 
For example, placement of braces:
```
class Logger {
 ...
};
```
or 
```
class Logger 
{
 ...
};
```
Either style may be used, and is dependent on the personal style of the developer.
Choosing one over the other does not affect the readability of the code, but if both are used in a mixed manner, it leads to bad aesthetics due to inconsistent patterns
> #### KEY IDEA:
> consistent style is more important than the "right" style.
---
## Conclusion
In short, through the chapter we learnt: 
- An aesthetically good code helps readers understand the code faster.
- The following techniques are used to make the code look aesthetically pleasing:
    1. If multiple blocks of code are doing similar things, try to give them the same silhouette.
    2. Aligning parts of the code into “columns” can make code easy to skim through.
    3. If code mentions A, B, and C in one place, don’t say B, C, and A in another. Pick a
       meaningful order and stick with it.
    4. Use empty lines to break apart large blocks into logical “paragraphs.”
---
## Authors
- *Sai Harshit B*
- *Prajwal HM*