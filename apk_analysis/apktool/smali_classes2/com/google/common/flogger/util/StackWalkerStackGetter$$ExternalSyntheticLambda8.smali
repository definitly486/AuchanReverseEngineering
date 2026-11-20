.class public final synthetic Lcom/google/common/flogger/util/StackWalkerStackGetter$$ExternalSyntheticLambda8;
.super Ljava/lang/Object;
.source "R8$$SyntheticClass"

# interfaces
.implements Ljava/util/function/Predicate;


# instance fields
.field public final synthetic f$0:Ljava/lang/String;


# direct methods
.method public synthetic constructor <init>(Ljava/lang/String;)V
    .locals 0

    .line 0
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/google/common/flogger/util/StackWalkerStackGetter$$ExternalSyntheticLambda8;->f$0:Ljava/lang/String;

    return-void
.end method


# virtual methods
.method public final test(Ljava/lang/Object;)Z
    .locals 1

    .line 0
    iget-object v0, p0, Lcom/google/common/flogger/util/StackWalkerStackGetter$$ExternalSyntheticLambda8;->f$0:Ljava/lang/String;

    check-cast p1, Ljava/lang/StackWalker$StackFrame;

    invoke-static {v0, p1}, Lcom/google/common/flogger/util/StackWalkerStackGetter;->$r8$lambda$rofYdNaDQStM0XYX4YPCxmNQpUk(Ljava/lang/String;Ljava/lang/StackWalker$StackFrame;)Z

    move-result p1

    return p1
.end method
