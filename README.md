# Codetox for Unity
Codetox is a general purpose script library to make your life easier.

## Quick install
To start using **Codetox** in your Unity project go to your package manager, click on [add package from git URL](https://docs.unity3d.com/2021.2/Documentation/Manual/upm-ui-giturl.html "Unity Documentation - Installing from a Git URL"), and paste the following URL:
```
https://github.com/aruizrab/codetox-for-unity.git
```

## Coroutine Builder
Coroutine Builder let's you create Unity coroutines on the go without the need to create ```IEnumerator``` methods and calling ```StartCoroutine()```

### Quick start
To start using Coroutine Builder call the ```Coroutine()``` method from your MonoBehaviour script:
```csharp
public class MyScript: MonoBehaviour 
{
    void Start()
    {
        // Debug.Log("Hello world!") will be called after 3 seconds
        this.Coroutine().WaitForSeconds(3f).Invoke(() => Debug.Log("Hello world!")).Run();
    }
}
```

### How to...?

#### Delay execution between methods calls
With Coroutine Builder you can specify a sequence of methd calls and add delays between them.
```csharp
this.Coroutine().
    Invoke(() => Debug.Log("Do something and wait 3 seconds...")).
    WaitForSeconds(3f).
    Invoke(() => Debug.Log("Do something else and wait 3 more seconds...")).
    WaitForSeconds(3f).
    Invoke(() => Debug.Log("Do one last thing")).
    Run();
```

#### Call methods a certain amount of times with a delay between calls
```csharp
this.Coroutine().
    Invoke(() => Debug.Log("Do something 4 times with one second delay")).
    WaitForSeconds(1f).
    ForTimes(4).
    Run();
```

#### Call methods every amount of seconds while a contiditon is met
```csharp
this.Coroutine().
    Invoke(() => Debug.Log("Shoot!")).
    WaitForSeconds(1f / fireRate).
    While(() => isShooting).
    Run();
```

#### Call a method, wait for a condition to be met, and call another method
```csharp
this.Coroutine().
    Invoke(() => Debug.Log("Do something")).
    WaitUntil(() => someCondition).
    Invoke(() => Debug.Log("Do something else")).
    Run();
```

#### Call a method, wait while a condition is met, and call another method
```csharp
this.Coroutine().
    Invoke(() => Debug.Log("Do something")).
    WaitWhile(() => someCondition).
    Invoke(() => Debug.Log("Do something else")).
    Run();
```

#### Keep a reference of your created coroutine
```csharp
var myCoroutine = this.Coroutine().
    Invoke(() => Debug.Log("Hello")).
    WaitForSeconds(1f).
    While(() => true);
    
myCoroutine.Run();
myCoroutine.Cancel();
```

### How does it work?
Coroutine Builder acts as a wrapper component for one coroutine. Every time you call the ```Coroutine()``` method a new component of type ```CoroutineBuilder``` is attached to your game object and a reference to this component is returned, with this reference you can specify the coroutine execution steps and finally call the method ```Run()``` to start the execution of your coroutine.
By default, once the execution of a coroutine is finished, the ```CoroutineBuilder``` component attached to your game object is destroyed.
