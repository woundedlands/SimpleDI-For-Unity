# SimpleDI for Unity

A lightweight, attribute-based Dependency Injection (DI) system for Unity. Resolve dependencies from parents, children, the scene, or the component itself with minimal boilerplate

---

## Installation

Unity 2019+ is supported (Including Unity 6)

1. Download the latest `.unitypackage` from [Releases](https://github.com/woundedlands/SimpleDI-For-Unity/releases/latest).
2. Import the package into your Unity project.

---

## Setup

1. **Add `SimpleDIApi` to your scene**:

   - Ensure it is the **first GameObject** in the scene hierarchy to initialize properly

2. **(Optional) Configure Options**:

   - Assign it to the `options` field in the `SimpleDIApi` component to change settings like logging

---

## Usage

### Attributes

Use attributes to mark fields for dependency resolution:

```csharp
[ResolveFromParent] private Rigidbody _parentRigidbody;
[ResolveFromChild] private Collider _childCollider;
[ResolveFromScene] private GameManager _gameManager;
[ResolveFromSelf] private Animator _selfAnimator;

private void Start()
{
    // Important!
    // ResolveDependencies should be called in order to resolve dependencies
    // For example in Start or Awake
    this.ResolveDependencies();
}
```

### [ResolveFromParent]

#### Resolved from nearest parent in hierarchy

### [ResolveFromChild]

#### Resolved from any nested child

### [ResolveFromScene]

#### Resolved from scene. Searches to the root, then searches all children, then searches other hierarchies inside current scene. First found is resolved

### [ResolveFromSelf]

#### Resolved from the same Game Object

### Each injection can be optional. If Component is not found it will be null and no warning will be logged. Add true to make attribute optional:

```csharp
[ResolveFromParent(true)]
```

### Interfaces are also supported:

```csharp
[ResolveFromParent] IMyType myType
```
