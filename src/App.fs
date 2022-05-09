module App

open System

open Browser.Dom

open Fable.Core
open Fable.Core.JsInterop

/// jQuery API.
type IjQueryElement =

    /// Animates towards the given CSS properties.
    abstract animate : properties : obj -> unit

    /// Handles a click event.
    abstract click : handler : (unit -> unit) -> unit

    /// Gets value of CSS property.
    abstract css : propertyName : string -> string

    /// Handles a document's ready event.
    abstract ready : handler : (unit -> unit) -> unit

    // import jQuery library
importDefault<unit> "jquery"

/// Selects a jQuery element.
[<Emit("$($0)")>]
let select _selector : IjQueryElement = jsNative

/// Parses pixel length. E.g. "100px" -> 100.0.
let parsePx (str : string) =
    assert(str.EndsWith("px"))
    str.Substring(0, str.Length - "px".Length)
        |> Double.Parse

(select document).ready (fun () ->

        // prepare to animate
    let img = select "#imgFable"
    let div = select "#divSurface"
    let btn = select "#btnGo"
    let imgWidth = img.css "width" |> parsePx
    let divWidth = div.css "width" |> parsePx

        // animate on button click
    btn.click (fun () ->
        let value =
            let left = img.css "left" |> parsePx
            $"{divWidth - imgWidth - left}px"
        img.animate {| left = value |}))
