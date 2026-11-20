.class public final Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;
.super Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;
.source "CaretString.kt"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x19
    name = "FORWARD"
.end annotation


# instance fields
.field private final autocompleteValue:Z


# direct methods
.method public constructor <init>(Z)V
    .locals 1

    const/4 v0, 0x0

    .line 23
    invoke-direct {p0, v0}, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity;-><init>(Lkotlin/jvm/internal/DefaultConstructorMarker;)V

    iput-boolean p1, p0, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;->autocompleteValue:Z

    return-void
.end method


# virtual methods
.method public final getAutocompleteValue()Z
    .locals 1

    .line 23
    iget-boolean v0, p0, Lcom/redmadrobot/inputmask/model/CaretString$CaretGravity$FORWARD;->autocompleteValue:Z

    return v0
.end method
