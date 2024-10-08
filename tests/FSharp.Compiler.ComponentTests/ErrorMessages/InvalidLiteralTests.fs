﻿// Copyright (c) Microsoft Corporation.  All Rights Reserved.  See License.txt in the project root for license information.

namespace ErrorMessages

open Xunit
open FSharp.Test.Compiler

module ``Invalid literals`` =

    [<Fact>]
    let ``Using Active Pattern``() =
        FSharp """
let (|A|) x = x + 1
let [<Literal>] (A x) = 1
        """
        |> typecheck
        |> shouldFail
        |> withSingleDiagnostic (Error 3396, Line 3, Col 17, Line 3, Col 22, "A [<Literal>] declaration cannot use an active pattern for its identifier")
