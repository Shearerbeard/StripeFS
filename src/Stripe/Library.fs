namespace StripeFS.Types

type Undefined = exn

namespace StripeFS

open StripeFS.Types
open Stripe

module Util =
    let tryCatch f x =
        try
            f x |> Ok
        with
        | ex -> Error ex.Message

module Config =
    let setApiKey keyStr = Stripe.StripeConfiguration.ApiKey = keyStr

module Customer =
    open Util
    let createCustomer name email =
        let shipping = ShippingOptions(
            Address = AddressOptions(
                Line1 = "10421 W Skycrest Dr",
                City = "Boise",
                State = "ID",
                PostalCode = "83704",
                Country = "US"))

        CustomerCreateOptions(
            Name = name,
            Email = email,
            Shipping = shipping)
        |> (tryCatch <| CustomerService().Create)

module Subscription =
    open Util
    let createSubscription customerId priceId =
        SubscriptionCreateOptions(
            Customer = customerId,
            Items =
                 ResizeArray<SubscriptionItemOptions> [SubscriptionItemOptions(Price = priceId)])
        |> (tryCatch <| SubscriptionService().Create)


module Say =
    let hello name =
        printfn "Hello %s" name
