# Threax.AspNetCore.CSP
This library provides middleware for setting up a csp in an asp.net core application.

## How to Use
### Configure Policy
In Startup.ConfigureServices add the following code:
```
    services.AddThreaxCSP(o =>
    {
        o.AddDefault().AddNone();
        o.AddImg().AddSelf();
        o.AddConnect().AddSelf();
        o.AddManifest().AddSelf();
        o.AddFont().AddSelf();
        o.AddFrame().AddSelf();
        o.AddScript().AddSelf();
        o.AddStyle().AddSelf();
        o.AddFrameAncestors().AddSelf();
    });
```
This will configure the csp to allow only the current page. Each item can be further modified to include more sources. There are several built in configuration functions you can use.
 * AddSelf - Add a 'self' entry to the policy.
 * AddNone - Add a 'none' entry to the policy.
 * AddUnsafeInline - Add an 'unsafe-inline' entry to the policy. Be careful with this.
 * AddUnsafeEval - Add an 'unsafe-eval' entry to the policy. Be careful with this.
 * AddData - Add a data: entry to the policy. This allows inline data elements in css or on the page to work.
 * AddEntries - If you have other entries, like urls or new policies this library doesn't support you can add them with AddEntries, which will just add the strings you pass in.

### Add to _ViewImports.cshtml
Add `@addTagHelper *, Threax.AspNetCore.CSP` to your view imports. That will make sure razor picks up the tag helper.

### Add Tag Helper
On any pages, or in your shared layouts add a `<threax-csp></threax-csp>` element to your page. This tag helper doesn't render anything, but it will add the csp header to the responses when this page, or shared template is rendered.

### Nonce Support
If you add nonce support to a policy with .AddNonce() you can then use the tag helper `csp-nonce` on any elements that you want a nonce on. This will be randomly generated each request.