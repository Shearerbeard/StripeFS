namespace StripeFS

namespace StripeFS.Types

type Undefined = exn

namespace StripeFS
open StripeFS.Types
module Customer =
    open Stripe
    let createCustomer name  = Undefined

module Subscription =
    let createSubscription = Undefined

module Say =
    let hello name =
        printfn "Hello %s" name
