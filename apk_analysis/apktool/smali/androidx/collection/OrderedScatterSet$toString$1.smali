.class final Landroidx/collection/OrderedScatterSet$toString$1;
.super Lkotlin/jvm/internal/Lambda;
.source "OrderedScatterSet.kt"

# interfaces
.implements Lkotlin/jvm/functions/Function1;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Landroidx/collection/OrderedScatterSet;->toString()Ljava/lang/String;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x18
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Landroidx/collection/OrderedScatterSet;


# direct methods
.method constructor <init>(Landroidx/collection/OrderedScatterSet;)V
    .locals 0

    .line 0
    iput-object p1, p0, Landroidx/collection/OrderedScatterSet$toString$1;->this$0:Landroidx/collection/OrderedScatterSet;

    const/4 p1, 0x1

    invoke-direct {p0, p1}, Lkotlin/jvm/internal/Lambda;-><init>(I)V

    return-void
.end method


# virtual methods
.method public final invoke(Ljava/lang/Object;)Ljava/lang/CharSequence;
    .locals 1

    .line 498
    iget-object v0, p0, Landroidx/collection/OrderedScatterSet$toString$1;->this$0:Landroidx/collection/OrderedScatterSet;

    if-ne p1, v0, :cond_0

    .line 499
    const-string p1, "(this)"

    return-object p1

    .line 501
    :cond_0
    invoke-static {p1}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object p1

    return-object p1
.end method

.method public bridge synthetic invoke(Ljava/lang/Object;)Ljava/lang/Object;
    .locals 0

    .line 497
    invoke-virtual {p0, p1}, Landroidx/collection/OrderedScatterSet$toString$1;->invoke(Ljava/lang/Object;)Ljava/lang/CharSequence;

    move-result-object p1

    return-object p1
.end method
