# XR_Avatar
This sample Unity project provides a networked IK-rigged avatar for the  Oculus Quest. With this solution, developers can freely create multiplayer games with an IK Rig and Hand Tracking. The system works by synchronizing the joint positions of an IK rig with a local player’s VR Rig over a network session. This system depends on a skeletal avatar (e.g., Ready Player Me), the Unity Animation Rigging package, the Unity NetCode for GameObjects package, and the Oculus Quest Integration SDK.

## Install:

### Technical runtime details
The system runtime begins with a pre-defined mapping between an IK rig and VR rig. The script of interest here is the AvatarMapping. In short, this script translates the local coordinates of the VR rig into the local coordinates of the IK Rig.

Upon connecting to the network (e.g., as host or client), the Local Player Rig is then mapped to the network-instantiated player prefab. If the network-instantiated player prefab is not owned locally (i.e., another player), all the AvatarRigging components are disabled/destroyed. The Animation Rigging components for a remote player instance remain active because the ClientNetworkTransform components communicate and synchronize a client’s VR Rig joint positions. 

### Avatar Rig Details
To use the XR Avatar prefab without networking, simply navigate into the Prefabs folder and use the XR Player prefab. To edit the network player prefab, open the XR Networked Avatar prefab. For a thorough breakdown of the avatar scripts, please check out these awesome YouTube tutorials provided by ____. 

For the feet, the system simply checks if the user’s head has moved past a threshold distance value and invokes a walking animation via the Avatar’s animator. If the user’s head movement doesn’t exceed the threshold, the Avatar’s animator switches to/remains in the idle animation state. The rigging of the feet is an area of improvement.

For the hands (and all other tracked joints listed in the AvatarMapping component), an offset is applied. These values can be adjusted at runtime to fine-tune for other purposes. 

## Additional Resources:
To run the project locally for both host/server and client, simply use the Parall package (specified in the package-config) to duplicate the project instance. (More details here)

To better understand the Animation Rigging of the player skeleton, please review the docs here and check out this YouTube tutorial here.

To better understand Unity NetCode, review the docs here and check out this YouTube tutorial here.

## Third Party Assets:

## License
<!-- Released under the [MIT license](LICENSE). -->

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

The MIT License (MIT)

Copyright © 2022 Alireza Bahremand

Permission is hereby granted, free of charge, to any person obtaining a copyof this software and associated documentation files (the "Software"), to dealin the Software without restriction, including without limitation the rightsto use, copy, modify, merge, publish, distribute, sublicense, and/or sellcopies of the Software, and to permit persons to whom the Software isfurnished to do so, subject to the following conditions:The above copyright notice and this permission notice shall be included in allcopies or substantial portions of the Software.THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS ORIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THEAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHERLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THESOFTWARE.

<!-- ### LicenseCopyright © 2022, [Alireza Bahremand](https://github.com/TheWiselyBearded).Released under the [MIT license](LICENSE). -->
