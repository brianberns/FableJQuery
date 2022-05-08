module App

open System

open Browser.Dom
open Browser.Types

open Fable.Core
open Fable.Core.JsInterop

/// JQuery API.
type IJQuery =

    /// Gets value of CSS property.
    abstract css : propertyName : string -> string

    /// Animates towards the given CSS properties.
    abstract animate: properties : obj -> IJQuery

/// Import JQuery.
let jq = importDefault<IJQuery> "jquery"

/// Selects a JQuery object.
[<Emit("$($0)")>]
let select selector : IJQuery = jsNative

/// Parses pixel length. E.g. "100px" -> 100.0.
let parsePx (str : string) =
    assert(str.EndsWith("px"))
    str.Substring(0, str.Length - 2)
        |> Double.Parse

    // animate on button click
let btnGo =
    document.getElementById("btnGo")
        :?> HTMLButtonElement
btnGo.onclick <-

    let jqImg = select "#imgFable"
    let jqDiv = select "#divSurface"
    let imgWidth = jqImg.css "width" |> parsePx
    let divWidth = jqDiv.css "width" |> parsePx

    fun _ ->
        let left = jqImg.css "left" |> parsePx
        let value = sprintf "%Apx" (divWidth - imgWidth - left)
        jqImg.animate {| left = value |}
