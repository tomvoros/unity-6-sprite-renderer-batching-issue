# unity-6-sprite-renderer-batching-issue 

Based on a test project by Dean Isseyegh here:
https://github.com/DeanIsseyegh/unity-6-sprite-render-anim-issue

This is a simple test project demonstrating (what appears to be) a draw call batching issue with SpriteRenderers in Unity 6 and URP.

Forum post:
https://discussions.unity.com/t/dynamic-draw-call-batching-seems-to-mix-up-sprites-between-spriterenderers-at-random/1602831

# Instructions

Start project up and open "SampleScene.unity" with Unity version 6000.0.38f1.

Play the scene.

Click "Toggle Shape 1" to deactivate shape 1, and again to reactivate. Click "Toggle Shape 2" to deactivate shape 2, and again to reactivate. Notice that shape 1 or 2 (inconsistent) will break.

![GIF 2025-02-19 1-55-45 PM](https://github.com/user-attachments/assets/cf08a4cb-8def-4b30-abda-afa663f0dec4)

# Details

When you have multiple SpriteRenderer objects that share a material AND include Animator components that modify a material property, toggling those objects off and back on will cause the rendered textures to get mixed up. One or more of the SpriteRenderers will display the wrong sprite texture (although with the correct vertices/UVs). Destroying the Animator components fixes the issue.

In this test project, I'm using a zero length animation that modifies the "_DummyProperty" material property. This property doesn't exist on the shader so it shouldn't have any effect.
