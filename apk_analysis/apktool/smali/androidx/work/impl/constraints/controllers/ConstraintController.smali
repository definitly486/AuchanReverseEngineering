.class public interface abstract Landroidx/work/impl/constraints/controllers/ConstraintController;
.super Ljava/lang/Object;
.source "ContraintControllers.kt"


# virtual methods
.method public abstract hasConstraint(Landroidx/work/impl/model/WorkSpec;)Z
.end method

.method public abstract isCurrentlyConstrained(Landroidx/work/impl/model/WorkSpec;)Z
.end method

.method public abstract track(Landroidx/work/Constraints;)Lkotlinx/coroutines/flow/Flow;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Landroidx/work/Constraints;",
            ")",
            "Lkotlinx/coroutines/flow/Flow<",
            "Landroidx/work/impl/constraints/ConstraintsState;",
            ">;"
        }
    .end annotation
.end method
