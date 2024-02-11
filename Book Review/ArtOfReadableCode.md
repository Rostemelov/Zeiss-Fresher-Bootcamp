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
In this example we also see that there's a typo for request in the third line. Using column alignment can help spot typos more easily.
### 4. Pick a Meaningful Order, and Use It Consistently

### 5. Organize Declarations into Blocks

### 6. Break Code into “Paragraphs”
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