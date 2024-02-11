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

#### 1. Rearrange Line Breaks to Be Consistent and Compact
Using line breaks can help to align the code and show a consistent style, especially, when there are statements of varying length, and some exceed the character limit of the line and overflow into next line while others don't. 

It can also be used to keep the width of the code small enough to avoid horizontal scrolling.

#### 2. Use Methods to Clean Up Irregularity
Here, we improve the readability of the code using **Helper Functions**. 

These helper functions hide away the details of how things work in order to present a neat code, as well as overcome the issue of code repeated code.

#### 3. Use Column Alignment When Helpful
Straight edges and columns make it easier to scan through the code. 

Using column alignment can help spot typos more easily. Similarly we can use for repetitve method calling where we pass arguements. One benefit is that we can easily spot if there have been typos or missing values in the arguements.


#### 4. Pick a Meaningful Order, and Use It Consistently
There are cases where the order of the code doesn't affect the correctness of the code. Yet it is important to keep a meaningful order, and stick to it to avoid confusion and to make typos more visible.


#### 5. Organize Declarations into Blocks
The brain naturally thinks in terms of groups and hierarchies.
Organizing the code into groups of related items, for examples functions within a class. Grouping them into similar types can help the reader better understand the categories of functions in the class.


#### 6. Break Code into “Paragraphs”
In written text, we split the content into paragraphs to group similar ideas, and to provide a visual "stepping stone" to the reader to help him/her understand better. 

This can be really helpful when used within large functions to visualise the steps within the function to understand its working.

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
---
> [Find the detailed review with examples here](https://github.com/Rostemelov/Zeiss-Fresher-Bootcamp/blob/main/Book%20Review/ArtOfReadableCode.md#authors)
